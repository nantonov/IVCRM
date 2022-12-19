import * as signalR from "@microsoft/signalr";
import { Badge, IconButton, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import { signalrConfig } from "../../config/signalrConfig";

const UnprocessedOrdersBadge = () => {

  const[unprocessedOrders, setUnprocessedOrders] = useState(0)

  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl(signalrConfig.HubUrl)
      .withAutomaticReconnect()
      .build();
  
    connection.start()
    .then(result => {
        console.log('Connected!');
  
        connection.on(signalrConfig.NotificationMethod, message => {
          console.log(message);
          setUnprocessedOrders(message)
          
        });
    })
    .catch(e => console.log('Connection failed: ', e));
  }, []);

  return (
    <Badge color="warning" badgeContent={unprocessedOrders} max={99}>
        <IconButton color={unprocessedOrders > 0 ? "warning" : "secondary"} aria-label="add to shopping cart">
            <AddShoppingCartIcon />
        </IconButton>
    </Badge>
  );
}

export default UnprocessedOrdersBadge;