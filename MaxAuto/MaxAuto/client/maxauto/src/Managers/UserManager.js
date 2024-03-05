const apiUrl = "https://localhost:7051";

export const login = (userObject) => {
	return fetch(`${apiUrl}/api/user/getbyemail?email=${userObject.email}`)
		.then((r) => r.json())
		.then((user) => {
			if (user.id && user.userStatusId !== 2) {
				localStorage.setItem("user", JSON.stringify(user));
				return user;
			} else {
				return undefined;
			}
		});
};

export const logout = () => {
	localStorage.clear();
};

export const register = (userObject, password) => {
	return fetch(`${apiUrl}/api/user`, {
		method: "POST",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(userObject),
	})
		.then((response) => response.json())
		.then((savedUser) => {
			localStorage.setItem("user", JSON.stringify(savedUser));
		});
};

export const getAllUsers = () => {
	return fetch(`${apiUrl}/api/user`).then((res) => res.json());
};

export const getUserById = (id) => {
	return fetch(`${apiUrl}/api/User/GetById/${id}`).then((res) =>
		res.json()
	);
};

export const updateMoney = (user) => {
	return fetch(`${apiUrl}/api/User/UpdateMoney/${user.id}`, {
		method: "PUT",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(user),
	});
};

// return (
//   <UserProfileContext.Provider value={{ isLoggedIn, login, logout, register,  }}>
//      {props.children}
//   </UserProfileContext.Provider>

// );