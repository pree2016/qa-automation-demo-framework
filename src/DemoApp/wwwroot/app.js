const form = document.getElementById('loginForm');
const message = document.getElementById('message');

form.addEventListener('submit', async (event) => {
  event.preventDefault();

  const payload = {
    email: document.getElementById('email').value,
    password: document.getElementById('password').value
  };

  message.textContent = 'Signing in...';
  message.className = 'message';

  try {
    const response = await fetch('/api/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(payload)
    });

    const data = await response.json();

    if (!response.ok || !data.success) {
      message.textContent = data.message || 'Login failed.';
      message.className = 'message error';
      return;
    }

    message.textContent = data.message;
    message.className = 'message success';
  } catch (error) {
    message.textContent = 'Unexpected error while calling the API.';
    message.className = 'message error';
  }
});
