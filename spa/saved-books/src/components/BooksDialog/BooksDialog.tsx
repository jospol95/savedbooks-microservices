import React, {useState} from "react";
import {Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField} from "@mui/material";
import BooksList from "../BooksList/BooksList";
import IBook from "../../types/Book";

export interface SimpleDialogProps {
    open: boolean;
    // selectedValue: string;
    onClose: () => void;
}


const BooksDialog: React.FC<{open: boolean, onClose: () => void}> = ({ onClose, open }) => {
    const [title, setTitle] = useState<string>('');
    const [author, setAuthor] = useState<string>();
    const [libraryName, setLibraryName] = useState<string>();
    const [fee, setFee] = useState<string>();
    const handleClose = () => {
        onClose();
    };
    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setTitle(event.target.value);
    }
        const pushToState = () => {
        console.log(title);
        onClose();
    }
    // let title = '' as string;
    // let book = {} as IBook;
    return (
        <Dialog open={open} onClose={handleClose}>
            <DialogTitle>Borrow a new book</DialogTitle>
            <DialogContent>
                <DialogContentText>
                    You can search for the book in the list or add your own
                </DialogContentText>
                <TextField
                    required
                    autoFocus
                    margin="dense"
                    id="name"
                    label="Book name"
                    type="text"
                    fullWidth
                    value={title}
                    onChange={e => setTitle(e.target.value)}
                    variant="standard"
                />
                <TextField
                    autoFocus
                    margin="dense"
                    id="name"
                    label="Author"
                    type="text"
                    // fullWidth
                    variant="standard"
                />
                <br />
                <TextField
                    required
                    autoFocus
                    margin="dense"
                    id="name"
                    label="Library"
                    type="text"
                    variant="standard"
                />&nbsp;
                <TextField
                    required
                    autoFocus
                    margin="dense"
                    id="name"
                    label="Daily fee"
                    type="number"
                    variant="standard"
                />
            </DialogContent>
            <DialogActions>
                <Button onClick={handleClose} color="primary">Cancel</Button>
                <Button variant="contained"  color="success" onClick={pushToState}>Add</Button>
            </DialogActions>
        </Dialog>
    )
}

export default BooksDialog
