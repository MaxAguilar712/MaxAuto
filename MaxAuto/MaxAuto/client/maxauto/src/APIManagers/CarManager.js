import React from "react";

const apiUrl = "https://localhost:7051";

const baseUrl = `${apiUrl}/api/Car`;

export const getAllCars = () => {
  return fetch(baseUrl) 
    .then((res) => res.json())
};

// export const addCars = (singleCar) => { 
//   return fetch(baseUrl, {
//     method: "POST",
//     headers: {
//       "Content-Type": "application/json",
//     },
//     body: JSON.stringify(singleCar),
//   });
// };
// //https://localhost:5001/api/Car/search?q=stop&sortDesc=true
// export const SearchCars = (searchTerm) => {
//     return fetch(`${baseUrl}/search?q=${searchTerm}&sortDesc=true`)
//     .then((res) => res.json())
// }

// //https://localhost:5001/api/Car/GetWithComments
// export const getAllCarsWithComments = () => {
//     return fetch(`${baseUrl}/GetWithComments`)
//     .then((res) => res.json())
// }

// //https://localhost:5001/api/Post/1/PostWithComments
// export const getPostByIdWithComments = (id) => {
//     return fetch(`${baseUrl}/${id}/PostWithComments`)
//     .then((res) => res.json())
// }