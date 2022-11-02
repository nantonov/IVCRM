import React, { useMemo, useRef, useState } from "react";
import { sortAndDeduplicateDiagnostics } from "typescript";
import Counter from "./components/Counter";
import PostForm from "./components/PostForm";
import PostList from "./components/PostList";
import PostFilter from "./components/PostFilter";
import MyInput from "./components/UI/input/MyInput";
import MySelect from "./components/UI/select/MySelect";
import {usePosts} from "./hooks/usePosts";

import './styles/App.css';
import MyModal from "./components/UI/modal/MyModal";
import MyButton from "./components/UI/button/MyButton";

function App() {
  const [posts, setPosts] = useState([])
  const [filter, setFilter] = useState({sort: '', query: ''})
  const [modal, setModal] = useState(false)
  const sortedAndSearchedPosts = usePosts(posts, filter.sort, filter.query)

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
