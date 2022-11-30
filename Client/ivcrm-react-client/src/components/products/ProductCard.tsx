import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { Button, CardActionArea, CardActions } from '@mui/material';
import { IProduct } from '../../models/IProduct';


interface Props {
    product: IProduct
}

const ProductCard: React.FC<Props> = ({product}) =>  {
  return (
    <Card sx={{ maxWidth: 345 }}>
      <CardActionArea>
        <CardMedia
          component="img"
          height="140"
          image="https://commons.wikimedia.org/wiki/File:Sunflower_from_Silesia2.jpg"
          alt="green iguana"
        />
        <CardContent>
            <Typography variant="body2" color="text.secondary">
            {product.name}
          </Typography>
          <Typography gutterBottom variant="h5" component="div">
            {product.price + " $"}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            some description
          </Typography>
        </CardContent>
      </CardActionArea>
      <CardActions>
        <Button size="small" color="primary">
          Share
        </Button>
      </CardActions>
    </Card>
  );
}

export default ProductCard;
