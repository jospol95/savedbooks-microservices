import React, {FC, useEffect, useRef, useState} from 'react';
import {Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import CheckIcon from "@mui/icons-material/Check";
import './Books.css';
import BooksList from "../BooksList/BooksList";
import BooksDialog from "../BooksDialog/BooksDialog";
import IBook from "../../types/Book";
import ILibrary from "../../types/Library";
import BookService from "../../services/books-service";

interface BooksProps {}

// useEffect(() => {
//     retrieveTutorials();
// }, []);
//

// const Books

const Books: React.FC = () => {
    const [books, setBooks] = useState<Array<IBook>>([]);
    const [open, setOpen] = React.useState(false);

    const initialDataLoad = useRef(true);
    useEffect(() => {
        if(initialDataLoad.current){
            initialDataLoad.current = false;
            getBooks();
        }
    }, []);

    const getBooks = () => {
        BookService.getAll()
            .then((response: any) => {
                // console.log(response);
                console.log(response.data);
                setBooks(response.data);
                // console.log(books);

            })
            .catch((e: Error) => {
                console.log(e);
            });
    };

    // let open = false;
    const handleClickOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };
    const addNewBook = () => {
        const lib: ILibrary = {
            description: '',
            name: 'Municipal Library'
        }
        const book: IBook = {
            id: "abc",
            title: 'Harry Potter',
            description: 'Harry Potter book',
            library: lib,
            dailyFee: 0.25,
            dateTimeToReturn: new Date()
        }
        setBooks(current => [...current, book]);
    }

    const pushToState = () => {
        setOpen(false);

    };

    // const handleClose = () => {
    //     onClose(selectedValue);
    // };

    return (
        <div className="inner-content">
            <h3>Borrowed books</h3>
            <div className="actions-row">
                <Button variant="contained" color="primary"
                        onClick={handleClickOpen}
                        // onClick={addNewBook}
                        disableElevation startIcon={<AddIcon />}>
                    Borrow new book
                </Button>
                <Button variant="contained" color="secondary" disableElevation startIcon={<CheckIcon />}>
                    Mark as returned
                </Button>
            </div>
            <BooksList  books={books}/>
            <BooksDialog open={open} onClose={handleClose}>

            </BooksDialog>
        </div>
    )

}

export default Books;
