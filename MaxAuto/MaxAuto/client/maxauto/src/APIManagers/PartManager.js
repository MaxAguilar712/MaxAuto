import React from "react";

const apiUrl = "https://localhost:7051";

const baseUrl = `${apiUrl}/api/Part`;

export const getAllParts = () => {
  return fetch(baseUrl) 
    .then((res) => res.json())
};