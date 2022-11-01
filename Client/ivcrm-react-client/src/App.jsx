import React, { useRef, useState } from "react";
import { sortAndDeduplicateDiagnostics } from "typescript";
import Counter from "./components/Counter";
import PostForm from "./components/PostForm";
import PostList from "./components/PostList";

import './styles/App.css';

function App() {
  const [posts, setPosts] = useState([
    {id: 1, title: 'Javascript1', body: 'Description'},
    {id: 2, title: 'Javascript2', body: 'Description'},
    {id: 3, title: 'Javascript3', body: 'Description'},
  ])
  {/* 
  const [title, setTitle] = useState('')
  const [body, setBody] = useState('')
*/}

const createPost = (newPost) => {
  setPosts([...posts, newPost])
}

const removePost = (post) => {
  setPosts(posts.filter(x => x.id !== post.id))
}

  return (
    <div className="App">
        <PostForm create={createPost}/>
        <PostList remove={removePost} posts = {posts} title="LIST!!!"/>
      <Counter/>
      <Counter/>
    </div>
  );
}

export default App;
