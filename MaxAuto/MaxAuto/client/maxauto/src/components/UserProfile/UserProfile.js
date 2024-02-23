import React, { useEffect, useState } from "react";
import { getUserProfileById } from "../../Managers/UserProfileManager";
import { useParams } from "react-router-dom";

export default function UserProfile() {
  const [userProfiles, setUserProfiles] = useState([]);

  const { id } = useParams();

  const dateFormat = new Date(userProfiles.createDateTime).toLocaleDateString('en-US');

  useEffect(() => {
    getUserProfileById(id).then(setUserProfiles);
  }, []);

  return (
    <div>
      <div>{userProfiles.fullName}</div>
      <img src={userProfiles.imageLocation}/>
      <div>{userProfiles.displayName}</div>
      <div>{userProfiles.email}</div>
      <div>{dateFormat}</div>
      <div>{userProfiles?.userType?.name}</div>
    </div>
  );
}