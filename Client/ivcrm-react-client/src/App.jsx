import React, { useMemo, useRef, useState } from "react";
import { sortAndDeduplicateDiagnostics } from "typescript";
import Counter from "./components/Counter";
import PostForm from "./components/PostForm";
import PostList from "./components/PostList";
import PostFilter from "./components/PostFilter";
import MyInput from "./components/UI/input/MyInput";
import MySelect from "./components/UI/select/MySelect";

import './styles/App.css';
import MyModal from "./components/UI/modal/MyModal";
import MyButton from "./components/UI/button/MyButton";

function App() {
  const [posts, setPosts] = useState([
    {id: 1, title: 'Javascript1', body: 'Description3'},
    {id: 2, title: 'Javascript2', body: 'Description2'},
    {id: 3, title: 'Javascript3', body: 'Description1'},
  ])
  const [filter, setFilter] = useState({sort: '', query: ''})
  const [modal, setModal] = useState(false)
  {/* 
  const [title, setTitle] = useState('')
  const [body, setBody] = useState('')
*/}

{/* мемоификация, кеширование другими словами*/}
const sortedPosts = useMemo(() => {
  console.log('scscscsc')
  if(filter.sort){
    return [...posts].sort((a, b) => a[filter.sort].localeCompare(b[filter.sort]))
  }
  return posts;
}, [filter.sort, posts])

const sortedAndSearchedPosts = useMemo(() => {
  return sortedPosts.filter(post => post.title.toLowerCase().includes(filter.query))
}, [filter.query, sortedPosts])

const createPost = (newPost) => {
  setPosts([...posts, newPost])
  setModal(false)
}

const removePost = (post) => {
  setPosts(posts.filter(x => x.id !== post.id))
}

  return (
    <div className="App">
      <MyButton style={{marginTop: 30}} onClick={() => setModal(true)}>
        Create
      </MyButton>
        <MyModal visible={modal} setVisible={setModal}>
        <PostForm create={createPost}/>
        </MyModal>

        <hr style={{margin: '15px 0'}}/>
        <PostFilter filter={filter} setFilter={setFilter}/>

        <PostList remove={removePost} posts = {sortedAndSearchedPosts} title="LIST!!!"/>

      <Counter/>
      <Counter/>
    </div>
  );
}

export default App;
