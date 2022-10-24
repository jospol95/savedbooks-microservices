import React, {FC, useEffect} from 'react';
import {Button} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import CheckIcon from "@mui/icons-material/Check";
import './Books.css';
import BooksList from "./BooksList";

interface BooksProps {}

// useEffect(() => {
//     retrieveTutorials();
// }, []);
//

// const Books

const Books: React.FC = () => {
    // useEffect(() => {
    //     console.log('Called parent');
    // }, []);

    return (
        <div className="inner-content">
            <h3>Borrowed books</h3>
            <div className="actions-row">
                <Button variant="contained" color="primary" disableElevation startIcon={<AddIcon />}>
                    Borrow new book
                </Button>
                <Button variant="contained" color="secondary" disableElevation startIcon={<CheckIcon />}>
                    Mark as returned
                </Button>
            </div>
            <BooksList  />
        </div>
    )

}

export default Books;
