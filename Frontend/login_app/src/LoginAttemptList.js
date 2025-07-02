import React, { useMemo } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ login, time }) => (
	<li className="Attempt-Item">
		<div className="Attempt-Avatar">{login[0]?.toUpperCase() || "?"}</div>
		<div className="Attempt-Details">
			<span className="Attempt-Login">{login}</span>
			<span className="Attempt-Time">{time}</span>
		</div>
	</li>
);

const LoginAttemptList = ({ attempts, filter, setFilter }) => {
	const filteredAttempts = useMemo(
		() =>
			attempts.filter(a =>
				a.login.toLowerCase().includes(filter.toLowerCase())
			),
		[attempts, filter]
	);

	return (
		<div className="Attempt-List-Main">
			<p className="Attempt-List-Title">Recent activity</p>
			<input
				type="text"
				className="Attempt-Filter"
				placeholder="Filter by name..."
				value={filter}
				onChange={e => setFilter(e.target.value)}
			/>
			<ul className="Attempt-List">
				{filteredAttempts.length === 0 ? (
					<li className="Attempt-Item Attempt-Empty">No attempts</li>
				) : (
					filteredAttempts.map((a, idx) => (
						<LoginAttempt key={idx} login={a.login} time={a.time} />
					))
				)}
			</ul>
		</div>
	);
};

export default LoginAttemptList;