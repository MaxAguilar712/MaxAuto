import React, { useEffect, useState } from "react";
import { getUserById } from "../../Managers/UserManager";
import { useParams } from "react-router-dom";

export default function User() {
  const [user, setUsers] = useState([]);

  const { id } = useParams();

  const dateFormat = new Date(user.createDateTime).toLocaleDateString('en-US');

  useEffect(() => {
    getUserById(id).then(setUsers);
  }, []);

  return (
    <div>
      <div>{user.Name}</div>
      <div>{user.email}</div>
      <div>{user?.userType?.name}</div>
      <div>{user.money}</div>
    </div>
  );
}