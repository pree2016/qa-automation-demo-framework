using Allure.Net.Commons;
using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace PlaywrightTests;

[Allure.NUnit.AllureNUnit]
public class LoginUiTests
{
    private IPlaywright _playwright = null!;
    private IBrowser _browser = null!;
    private IBrowserContext _context = null!;
    private IPage _page = null!;
    private readonly string _baseUrl = Environment.GetEnvironmentVariable("APP_BASE_URL") ?? "http://localhost:5078";
    private readonly string _artifactsRoot = Path.Combine(
        Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory, "../../../../..")),
        "artifacts", "screenshots");
    private readonly string _videosRoot = Path.Combine(
        Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory, "../../../../..")),
        "artifacts", "videos");

    [SetUp]
    public async Task SetUp()
    {
        Directory.CreateDirectory(_artifactsRoot);
        Directory.CreateDirectory(_videosRoot);

        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            //Headless = true
            //Headless = false,
            //SlowMo = 500
            Headless = Environment.GetEnvironmentVariable("HEADLESS") != "false"
        });
        _context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            RecordVideoDir = _videosRoot,
            RecordVideoSize = new RecordVideoSize { Width = 1280, Height = 720 }
        });
        _page = await _context.NewPageAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        var isFailed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed;

        if (isFailed && _page is not null)
        {
            var safeTestName = string.Concat(TestContext.CurrentContext.Test.Name.Select(ch =>
                Path.GetInvalidFileNameChars().Contains(ch) ? '_' : ch));

            var screenshotPath = Path.Combine(_artifactsRoot, $"{safeTestName}.png");
            await _page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = screenshotPath,
                FullPage = true
            });
            AllureApi.AddAttachment("Failure Screenshot", "image/png", screenshotPath);
            TestContext.WriteLine($"Failure screenshot saved: {screenshotPath}");
        }

        IVideo? video = null;
        if (_page is not null)
        {
            video = _page.Video;
            await _page.CloseAsync();
        }

        if (_context is not null)
        {
            await _context.CloseAsync();

            if (isFailed && video is not null)
            {
                var safeTestName = string.Concat(TestContext.CurrentContext.Test.Name.Select(ch =>
                        Path.GetInvalidFileNameChars().Contains(ch) ? '_' : ch));
                var videoSourcePath = await video.PathAsync();

                var videoDestPath = Path.Combine(_videosRoot, $"{safeTestName}.webm");
                File.Move(videoSourcePath, videoDestPath, overwrite: true);
                AllureApi.AddAttachment("Failure Video", "video/webm", videoDestPath);
                TestContext.WriteLine($"Failure video saved: {videoDestPath}");
            }
            else if (video is not null)
            {
                var videoSourcePath = await video.PathAsync();
                if (File.Exists(videoSourcePath))
                    File.Delete(videoSourcePath);
            }
        }

        if (_browser is not null)
        {
            await _browser.CloseAsync();
        }

        _playwright?.Dispose();
    }

    [Test]
    [Retry(2)]
    [Category("UI")]
    [Category("Smoke")]
    [Allure.NUnit.Attributes.AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    public async Task ValidLogin_ShowsWelcomeMessage()
    {
        await _page.GotoAsync(_baseUrl);
        await _page.FillAsync("#email", "qa.user@example.com");
        await _page.FillAsync("#password", "Password123!");
        await _page.ClickAsync("#loginButton");

        await ExpectMessageContains("Welcome, QA Demo User!");
    }

    [Test]
    [Allure.NUnit.Attributes.AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
    public async Task InvalidLogin_ShowsErrorMessage()
    {
        await _page.GotoAsync(_baseUrl);
        await _page.FillAsync("#email", "qa.user@example.com");
        await _page.FillAsync("#password", "WrongPassword!");
        await _page.ClickAsync("#loginButton");

        await ExpectMessageContains("Invalid email or password.");
    }

    private async Task ExpectMessageContains(string expected)
    {
        var locator = _page.Locator("#message");
        await Assertions.Expect(locator).ToContainTextAsync(expected);
    }
}
