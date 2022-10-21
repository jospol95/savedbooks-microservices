import React, { FC } from 'react';
import './Menu.css';

interface MenuProps {}

const Menu: FC<MenuProps> = () => (
  <div className="side-menu">
    <ul>
        <li>Books</li>
        <li>Libraries</li>
    </ul>
  </div>
);

export default Menu;
