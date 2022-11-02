import React, { useMemo, useRef, useState } from "react";
import { sortAndDeduplicateDiagnostics } from "typescript";
import Counter from "./components/Counter";
import PostForm from "./components/PostForm";
import PostList from "./components/PostList";
import PostFilter from "./components/PostFilter";
import MyInput from "./components/UI/input/MyInput";
import MySelect from "./components/UI/select/MySelect";

import './styles/App.css';

function App() {
  const [posts, setPosts] = useState([
    {id: 1, title: 'Javascript1', body: 'Description3'},
    {id: 2, title: 'Javascript2', body: 'Description2'},
    {id: 3, title: 'Javascript3', body: 'Description1'},
  ])
  const [selectedSort, setSelectedSort] = useState('')
  const [searchQuery, setSearchQuery] = useState('')
  {/* 
  const [title, setTitle] = useState('')
  const [body, setBody] = useState('')
*/}

{/* мемоификация, кеширование другими словами*/}
const sortedPosts = useMemo(() => {
  console.log('scscscsc')
  if(selectedSort){
    return [...posts].sort((a, b) => a[selectedSort].localeCompare(b[selectedSort]))
  }
  return posts;
}, [selectedSort, posts])

const sortedAndSearchedPosts = useMemo(() => {
  return sortedPosts.filter(post => post.title.toLowerCase().includes(searchQuery))
}, [searchQuery, sortedPosts])

const createPost = (newPost) => {
  setPosts([...posts, newPost])
}

const removePost = (post) => {
  setPosts(posts.filter(x => x.id !== post.id))
}

const sortPosts = (sort) => {
  setSelectedSort(sort);
}

  return (
    <div className="App">
        <PostForm create={createPost}/>
        <hr style={{margin: '15px 0'}}/>
        <PostFilter/>

        {sortedAndSearchedPosts.length !== 0
          ? <PostList remove={removePost} posts = {sortedAndSearchedPosts} title="LIST!!!"/>
          : <h1 style={{textAlign: 'center'}}>NO DATA</h1>
        }
        
      <Counter/>
      <Counter/>
    </div>
  );
}

export default App;
