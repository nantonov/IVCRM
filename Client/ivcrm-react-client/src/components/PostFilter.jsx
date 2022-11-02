import React from "react";
import MyInput from "./UI/button/MyInput";
import MySelect from "./UI/button/MySelect";

const PostFilter = (props) => {
    return (
        <div>
          <MyInput
            value={searchQuery}
            onChange={e => setSearchQuery(e.target.value)}
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
    )
}

export default PostFilter;