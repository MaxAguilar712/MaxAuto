import React from "react";
import { Card, CardImg, CardBody, Button } from "reactstrap";
import { Link } from "react-router-dom";
// import './Car.css';

export const CarPart = ({ carPart }) => {
  return (

          <li> <span>
           {carPart.name}
         </span> </li>

  );
};