import React, { useState} from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useNavigate } from "react-router-dom";
import { register } from "../Managers/UserManager";


export default function Register({setIsLoggedIn}) {
  const navigate = useNavigate();

  const [name, setName] = useState();
  const [email, setEmail] = useState();
  // const [password, setPassword] = useState();
  // const [confirmPassword, setConfirmPassword] = useState();

  const registerClick = (e) => {
    e.preventDefault();
    // if (password && password !== confirmPassword) {
    //   alert("Passwords don't match. Do better.");
    // } else {
      {
      const user = { name: name, email: email, userTypeId: 2,  };
      register(user)
        .then(() => {
          setIsLoggedIn(true);
          navigate('/');
        });
    };
 };

  return (
    <Form onSubmit={registerClick}>
      <fieldset>
        <FormGroup>
          <Label htmlFor="name">Name</Label>
          <Input id="name" type="text" onChange={e => setName(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input id="email" type="text" onChange={e => setEmail(e.target.value)} />
        </FormGroup>
        {/* <FormGroup>
          <Label for="password">Password</Label>
          <Input id="password" type="password" onChange={e => setPassword(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label for="confirmPassword">Confirm Password</Label>
          <Input id="confirmPassword" type="password" onChange={e => setConfirmPassword(e.target.value)} />
        </FormGroup> */}
        <FormGroup>
          <Button>Register</Button>
        </FormGroup>
      </fieldset>
    </Form>
  );
}