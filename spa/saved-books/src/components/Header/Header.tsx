import React, { FC } from 'react';
// import React from "react";
import './Header.css';

interface HeaderProps {}

const Header: FC<HeaderProps> = () => (
    <div className="Header">
        Saved Books Web
    </div>
);

// const Header = () => {
//     return (
//         <header className="Header">
//             Saved Books Web
//         </header>
//     )
// }

export default Header;
