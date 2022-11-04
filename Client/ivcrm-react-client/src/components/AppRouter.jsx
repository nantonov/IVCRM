import React, {useContext} from 'react';
import {Route} from "react-router-dom";
import {privateRoutes} from "../router";

const AppRouter = () => {
    return (

        privateRoutes.map(route =>
            <Route path={route.path}
                   exact={route.exact}
                   component={route.component}
                   key={route.path}
            />
        )
                
    );
};

export default AppRouter;