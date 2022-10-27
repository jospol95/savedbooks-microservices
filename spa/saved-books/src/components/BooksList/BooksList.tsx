import React, {useEffect, useRef, useState} from "react";
import BookService from "../../services/books-service";
import {DataGrid, GridColumns, GridValueFormatterParams} from "@material-ui/data-grid";
import IBook from "../../types/Book";


const columns : GridColumns = [
    {
        field: 'title',
        headerName: 'Book Title',
        flex: 0.2,
        editable: true,
    },
    {
        field: 'author',
        headerName: 'Author',
        flex: 0.2,
        editable: true,
    },
    {
        field: 'libraryName',
        headerName: 'Library',
        flex: 0.2,
        valueGetter: (params) => {
            return params.row.library.name
        },
        editable: true,
    },

    {
        field: 'dateTimeToReturn',
        headerName: 'Due date',
        description: 'This column has a value getter and is not sortable.',
        sortable: false,
        valueGetter: (params) => {
            return new Date(params.row.dateTimeToReturn).toDateString();
        },
        flex: 0.2,
    },
    {
        field: 'dailyFee',
        headerName: 'Fees',
        type: 'number',
        flex: 0.15,
        // editable: true,
    },
];

// const rows = [
//     { id: 1, title: 'The Alchemist', author: 'Paulo Coehlo', age: '$' + 0.25 },
//     { id: 2, title: 'Lannister', author: 'Cersei', age: '$' + 1 },
//     { id: 3, title: 'Lannister', author: 'Jaime', age: '$' + 0.00 },
// ];

const BooksList: React.FC<{books: IBook[]}> = ({books}) => {

    // const [books, setBooks] = useState<Array<IBook>>([]);
    // const [currentIndex, setCurrentIndex] = useState<number>(-1);
    // const [currentTutorial, setCurrentTutorial] = useState<IBookData | null>(null);
    // const [currentIndex, setCurrentIndex] = useState<number>(-1);
    // const [searchTitle, setSearchTitle] = useState<string>("");
    // const callApi = useRef(true);

    // useEffect(() => {
    //     if(callApi.current){
    //         callApi.current = false;
    //         retrieveTutorials();
    //     }
    // }, []);

    // const retrieveTutorials = () => {
    //     BookService.getAll()
    //         .then((response: any) => {
    //             console.log(response);
    //             console.log(response.data);
    //             setBooks(response.data);
    //             console.log(books);
    //
    //         })
    //         .catch((e: Error) => {
    //             console.log(e);
    //         });
    // };

    return (
        <div className="datagrid-ctainer">

            <DataGrid
                rows={books}
                columns={columns}
                pageSize={10}
                checkboxSelection
                disableSelectionOnClick
            />
        </div>
    )

}

export default BooksList
