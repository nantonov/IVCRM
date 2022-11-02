import React, { useRef, useState } from "react";
import { sortAndDeduplicateDiagnostics } from "typescript";
import Counter from "./components/Counter";
import PostForm from "./components/PostForm";
import PostList from "./components/PostList";
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

const createPost = (newPost) => {
  setPosts([...posts, newPost])
}

const removePost = (post) => {
  setPosts(posts.filter(x => x.id !== post.id))
}

const sortPosts = (sort) => {
  setSelectedSort(sort);
  setPosts([...posts].sort((a, b) => a[sort].localeCompare(b[sort])))
}

  return (
    <div className="App">
        <PostForm create={createPost}/>
        <hr style={{margin: '15px 0'}}/>

        <div>
          <MyInput
            value={saerchQuery}
            onChange={e => setSearchQuery(e.terget.value)}
            placeholder="Search..."
            />
          <MySelect
            value={selectedSort}
            onChange={sortPosts}
            defaultValue="Sort"
            options={[
              {value: 'title', name: 'By title'},
              {value: 'body', name: 'By body'},
            ]}
            />
        </div>

        {posts.length !== 0
          ? <PostList remove={removePost} posts = {posts} title="LIST!!!"/>
          : <h1 style={{textAlign: 'center'}}>NO DATA</h1>
        }
        
      <Counter/>
      <Counter/>
    </div>
  );
}

export default App;
