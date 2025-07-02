import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';

const App = () => {
  const [loginAttempts, setLoginAttempts] = useState([]);
  const [filter, setFilter] = useState("");

  const handleLogin = ({ login, password }) => {
    setLoginAttempts(prev => [
      { login, password, time: new Date().toLocaleString() },
      ...prev
    ]);
  };

  return (
    <div className="App">
      <LoginForm onSubmit={handleLogin} />
      <LoginAttemptList 
        attempts={loginAttempts} 
        filter={filter} 
        setFilter={setFilter} 
      />
    </div>
  );
};

export default App;
