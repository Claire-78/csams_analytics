
import './App.css';
import React from "react";
import { BrowserRouter as Router, Route } from 'react-router-dom'
import ReactDOM from "react-dom";

import PostListAgain from './components/PostListAgain';
import Navbar from './components/Navbar/Navbar'

import Comments from './components/Comments';
import Assignments from './components/Assignments'
import MinMax from './components/MinMax';
import AssiComments from './components/AssiComments';
import Statistics from './components/Statistics';
import PostForm from './components/PostForm';
import ReviewerComments from './components/ReviewerComments';
import Filters from './components/Filters';

function App() {
    return (
        <Router>
            <div className="App">
                <Navbar />
                <Route path='/' exact>
                    <h1>

                        Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                        Ut enim ad minim veniam, quis nostrud exercitation
                        ullamco laboris nisi ut aliquip ex ea commodo consequat.
                        Duis aute irure dolor in reprehenderit in voluptate velit esse
                        cillum dolore eu fugiat nulla pariatur. Excepteur sint
                        occaecat cupidatat non proident, sunt in culpa qui
                        officia deserunt mollit anim id est laborum.

      </h1>
                </Route>
            </div>
            <Route path='/User' >
                <PostListAgain />
            </Route>

            
            <Route path='/Comments' >
                <Comments />
            </Route>

            <Route path='/Assignments' >
                <Assignments />
            </Route>

            <Route path='/Comment/Project/:id' component={AssiComments}>
            </Route>
            <Route path='/Comment/Reviewer/:id' component={ReviewerComments}>
            </Route>

            <Route path='/Post' >
                <PostForm />

            </Route>

            <Route path='/Max' >
                <MinMax />
            </Route>

            <Route path='/Statistics' >
                <Statistics />
            </Route>

            <Route path='/Filters' >
                <Filters />
            </Route>

        </Router>
    );
}

export default App;
