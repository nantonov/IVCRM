import React, { useState } from "react";
import MyButton from "./UI/button/MyButton";
import MyInput from "./UI/input/MyInput";

const PostForm = ({create}) => {
    const [post, setPost] = useState({title: '', body: ''})

    const addNewPost = (e) => {
        e.preventDefault()
    
           {/*Разворачиваем массив в новый массив и довый пост в конце*/}
          const newPost = {...post, id: Date.now()}
          create(newPost)
          setPost({title: '', body: ''})
      }

    return (
        <form>
        {/*Управляемый*/}
        <MyInput 
          value={post.title} 
          onChange={e => setPost({...post, title: e.target.value})} 
          type="text" 
          placeholder="Название поста"
          />
          {/*Неуправляемый*/}
        <MyInput           
          value={post.body} 
          onChange={e => setPost({...post, body: e.target.value})} 
          type="text" 
          placeholder="Описание поста"
          />
        
        <MyButton onClick={addNewPost}>MyButton</MyButton>
      </form>
    )
}

export default PostForm;