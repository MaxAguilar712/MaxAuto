const apiUrl = "https://localhost:5001";

export const login = (userObject) => {
	return fetch(`${apiUrl}/api/userprofile/getbyemail?email=${userObject.email}`)
		.then((r) => r.json())
		.then((userProfile) => {
			if (userProfile.id && userProfile.userStatusId !== 2) {
				localStorage.setItem("userProfile", JSON.stringify(userProfile));
				return userProfile;
			} else {
				return undefined;
			}
		});
};

export const logout = () => {
	localStorage.clear();
};

export const register = (userObject, password) => {
	return fetch(`${apiUrl}/api/userprofile`, {
		method: "POST",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(userObject),
	})
		.then((response) => response.json())
		.then((savedUserProfile) => {
			localStorage.setItem("userProfile", JSON.stringify(savedUserProfile));
		});
};

export const getAllUserProfiles = () => {
	return fetch(`${apiUrl}/api/userprofile`).then((res) => res.json());
};

export const getUserProfileById = (id) => {
	return fetch(`${apiUrl}/api/UserProfile/GetById/${id}`).then((res) =>
		res.json()
	);
};

export const updateUserStatus = (user) => {
	return fetch(`${apiUrl}/api/UserProfile/UpdateUserStatus/${user.id}`, {
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