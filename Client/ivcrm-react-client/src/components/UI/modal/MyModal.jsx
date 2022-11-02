import React from 'react';
import classes from './MyModal.module.css';

const MyModal = ({children, visible, setVisible}) => {

const rootClases = [classes.myModal]

if(visible)
{
    rootClases.push(classes.active)
}

    return (
        <div className={rootClases.join(' ')} onClick={() => setVisible(false)}>
            <div className={classes.myModalContent} onClick={(e) => e.stopPropagation()}>
                {children}
            </div>
        </div>
    );
};

export default MyModal;