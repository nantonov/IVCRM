import React, { useCallback, useState } from "react";
import styled from "styled-components";

interface Props {
    onFileUpload: (file: File) => void;
    inputProps: React.InputHTMLAttributes<HTMLInputElement>;
}

const Dropzone: React.FC<Props> = ({ onFileUpload, inputProps }) => {
    const [isDragOver, setIsDragOver] = useState(false);

  const handleDrop = useCallback((e: React.DragEvent<HTMLDivElement>) => {
    e.preventDefault();
    setIsDragOver(false);
    if (e.dataTransfer && e.dataTransfer.files) {
        onFileUpload(e.dataTransfer.files[0]);
    }
}, [onFileUpload]);

const handleFileInput = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      onFileUpload(e.target.files[0]);
    }
  }, [onFileUpload]);

const handleDragOver = (e: React.DragEvent<HTMLDivElement>) => {
    e.preventDefault()
  };
  
  const handleDragEnter = (e: React.DragEvent<HTMLDivElement>) => {
    e.preventDefault()
    setIsDragOver(true);
  };

  const handleDragLeave = useCallback((e: React.DragEvent<HTMLDivElement>) => {
    e.preventDefault();
    setIsDragOver(false);
  }, []);

  return (
    <DropzoneDiv>
        <div  onDragEnter={handleDragEnter} onDragLeave={handleDragLeave} onDragOver={handleDragOver} onDrop={handleDrop}>
        {isDragOver ? (
          <p>Drop your files here</p>
        ) : (
          <p> Drag and drop your files here or select them</p>
        )}
        </div>
        <input type="file" onChange={handleFileInput} {...inputProps}/>
    </DropzoneDiv>
  );
};

export default Dropzone;

const DropzoneDiv = styled.div`
  text-align: center;
  padding: 20px;
  border: dashed green;
  width: 60%;
  margin: auto;
`