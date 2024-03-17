import React from "react";

const apiUrl = "https://localhost:7051";

const baseUrl = `${apiUrl}/api/CarGarage`;

export const getAllGarageCars = () => {
  return fetch(baseUrl) 
   .then((res) => res.json())
};


export const buyGarageCar = (garageCar) => {
    return fetch(`${apiUrl}/api/CarGarage`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(garageCar),
    })
  };  

export const deleteGarageCar = (id) => {
  return fetch(`${apiUrl}/api/CarGarage/${id}`, { method: "DELETE" })
      .then((res) => res.json())
};

export const getGarageCarById = (garageCar) => {
  return fetch(`${apiUrl}/api/CarGarage/GetById/${garageCar.id}`) 
   .then((res) => res.json())
};


export const updateGarageCar = (garageCar) => {
	return fetch(`${apiUrl}/api/CarGarage/UpdateNickName/${garageCar.id}`, {
		method: "PUT",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(garageCar),
	});
};