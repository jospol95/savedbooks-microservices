import React from 'react';
import './App.css';
import Header from "./components/Header/Header";
import Menu from "./components/Menu/Menu";
import {Button} from "@mui/material";
import { DataGrid } from '@material-ui/data-grid';
import SendIcon from '@mui/icons-material/Delete';


const columns = [
    // { field: 'id', headerName: 'ID', width: 90, flex: 0.2, },
    {
        field: 'firstName',
        headerName: 'Book Title',
        flex: 0.2,
        editable: true,
    },
    {
        field: 'lastName',
        headerName: 'Author',
        flex: 0.2,
        editable: true,
    },
    {
        field: 'library',
        headerName: 'Library',
        flex: 0.2,
        editable: true,
    },

    {
        field: 'fullName',
        headerName: 'Due date',
        description: 'This column has a value getter and is not sortable.',
        sortable: false,
        flex: 0.2,
        // valueGetter: (params: any) =>
        //     `${params.getValue(params.id, 'firstName') || ''} ${
        //         params.getValue(params.id, 'lastName') || ''
        //     }`,
    },
    {
        field: 'age',
        headerName: 'Fees',
        type: 'number',
        flex: 0.1,
        editable: true,
    },
];

const rows = [
    { id: 1, lastName: 'The Alchemist', firstName: 'Paulo Coehlo', age: '$' + 0.25 },
    { id: 2, lastName: 'Lannister', firstName: 'Cersei', age: '$' + 1 },
    { id: 3, lastName: 'Lannister', firstName: 'Jaime', age: '$' + 0.00 },
    // { id: 4, lastName: 'Stark', firstName: 'Arya', age: 16 },
    // { id: 5, lastName: 'Targaryen', firstName: 'Daenerys', age: null },
    // { id: 6, lastName: 'Melisandre', firstName: null, age: 150 },
    // { id: 7, lastName: 'Clifford', firstName: 'Ferrara', age: 44 },
    // { id: 8, lastName: 'Frances', firstName: 'Rossini', age: 36 },
    // { id: 9, lastName: 'Roxie', firstName: 'Harvey', age: 65 },
];

function App() {
    return (
        <div className="App">
            <Header />
            <div className="App-header">
                <Menu />
                <div className="content">
                    <div className="inner-content">
                        <h3>Borrowed books</h3>
                        <div className="actions-row">
                            <Button variant="contained" color="primary" disableElevation startIcon={<SendIcon />}>
                                Borrow new book
                            </Button>
                            <Button variant="contained" color="secondary" disableElevation>
                                Mark as returned
                            </Button>
                        </div>
                        <div className="datagrid-ctainer">
                            <DataGrid
                                rows={rows}
                                columns={columns}
                                pageSize={10}
                                checkboxSelection
                                disableSelectionOnClick
                            />
                        </div>
                    </div>

                    {/*<p>this is content</p>*/}
                </div>
                {/*This is the app content*/}
            </div>
        </div>
    );
}

export default App;
