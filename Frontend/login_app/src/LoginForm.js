import React, { useState } from "react";
import './LoginForm.css';

const LoginForm = (props) => {
	const [login, setLogin] = useState("");
	const [password, setPassword] = useState("");
	const [error, setError] = useState("");

	const handleSubmit = (event) =>{
		event.preventDefault();
		if (!login.trim() || !password.trim()) {
			setError("Both name and password are required.");
			return;
		}
		setError("");
		props.onSubmit({
			login,
			password,
		});
		setLogin("");
		setPassword("");
	}

	return (
		<form className="form" onSubmit={handleSubmit}>
			<h1>Login</h1>
			{error && <div className="form-error">{error}</div>}
			<label htmlFor="name">Name</label>
			<input type="text" id="name" value={login} onChange={e => setLogin(e.target.value)} />
			<label htmlFor="password">Password</label>
			<input type="password" id="password" value={password} onChange={e => setPassword(e.target.value)} />
			<button type="submit">Continue</button>
		</form>
	)
}

export default LoginForm;