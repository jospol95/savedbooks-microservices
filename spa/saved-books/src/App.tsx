import React, {useEffect} from 'react';
import './App.css';
import Header from "./components/Header/Header";
import Menu from "./components/Menu/Menu";
import Books from "./components/Books/Books";
// import SendIcon from '@mui/icons-material/Delete';


function App() {
    // useEffect(() => {
    //     console.log('Called main');
    // }, []);
    return (
        <div className="App">
            <Header />
            <div className="App-header">
                <Menu />
                <div className="content">
                    <Books />
                    {/*<div className="inner-content">*/}
                    {/*    */}
                    {/*</div>*/}

                    {/*<p>this is content</p>*/}
                </div>
                {/*This is the app content*/}
            </div>
        </div>
    );
}

export default App;
