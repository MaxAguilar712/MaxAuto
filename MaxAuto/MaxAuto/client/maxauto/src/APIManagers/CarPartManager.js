
import React from "react";

const apiUrl = "https://localhost:7051";

const baseUrl = `${apiUrl}/api/CarPart`;

export const getAllCarParts = () => {
  return fetch(baseUrl) 
   .then((res) => res.json())
};


export const buyCarPart = (carPart) => {
    return fetch(`${apiUrl}/api/CarPart`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(carPart),
    })
  };  

export const deleteCarPart = (id) => {
  return fetch(`${apiUrl}/api/CarPart/${id}`, { method: "DELETE" })
      .then((res) => res.json())}