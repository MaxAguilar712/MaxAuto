import React, { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import { logout } from "../Managers/UserManager";
import {
	Collapse,
	Navbar,
	NavbarToggler,
	NavbarBrand,
	Nav,
	NavItem,
	NavLink,
} from "reactstrap";

import User from "./UserProfile/UserProfile";

export const Header = ({ isLoggedIn, setIsLoggedIn }) => {
	const [isOpen, setIsOpen] = useState(false);
	const toggle = () => setIsOpen(!isOpen);


	const user = JSON.parse(localStorage.getItem("user"));



	return (
		<div>
			<Navbar color='dark' dark expand='md'>
				<NavbarBrand tag={RRNavLink} to='/'>
					MAX AUTO
				</NavbarBrand>
				<NavbarToggler onClick={toggle} />
				<Collapse isOpen={isOpen} navbar>
					<Nav className='mr-auto' navbar>
						{/* When isLoggedIn === true, we will render the Home link */}
						{isLoggedIn && (
							<>
								<NavItem>
									<NavLink tag={RRNavLink} to='/'>
										Home
									</NavLink>
								</NavItem>
								<NavItem/>
								<NavLink tag={RRNavLink} to='/car-market'>Car Market</NavLink>
							{/* <NavItem>
									<NavLink tag={RRNavLink} to='/part-market'>
										Part Market
									</NavLink>
								</NavItem> */}
								<NavItem>
									<NavLink tag={RRNavLink} to='/my-garage'>
										My Garage
									</NavLink>
								</NavItem>
								{/* <NavItem>
									<NavLink tag={RRNavLink} to='/Tags'>
										Tag Management
									</NavLink>
								</NavItem>
								<NavItem>
									<NavLink tag={RRNavLink} to='/Categories'>
										Category Management
									</NavLink>
								</NavItem> */}
								{/* {user && user.userTypeId == 1 && (
									<NavItem>
										<NavLink tag={RRNavLink} to='/users'>
											Users
										</NavLink>
									</NavItem>
								)} */}
							</>
						)}
					</Nav>

					<Nav navbar>
						{isLoggedIn && (
							<>
								<NavItem>
									<a
										aria-current='page'
										className='nav-link'
										style={{ cursor: "pointer" }}
										onClick={() => {
											logout();
											setIsLoggedIn(false);
										}}
									>
										Logout
									</a>
								</NavItem>
								
							</>
						)}
						{!isLoggedIn && (
							<>
								<NavItem>
									<NavLink tag={RRNavLink} to='/login'>
										Login
									</NavLink>
								</NavItem>
								<NavItem>
									<NavLink tag={RRNavLink} to='/register'>
										Register
									</NavLink>
								</NavItem>
							</>
						)}
					</Nav>
				</Collapse>		
				
									<p classname="moneybar">
										
											Wallet: ${user?.money}
									</p>
			</Navbar>

		

									
							
		</div>
	);
};