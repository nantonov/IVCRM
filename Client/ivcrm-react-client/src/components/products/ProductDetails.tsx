import { Grid } from '@mui/material';
import styled from 'styled-components';
import { IProduct } from '../../models/IProduct';

interface Props {
  product: IProduct
}

const ProductDetails: React.FC<Props> = ({ product }) => {
  
  return (
    <StyledDiv>
      <ProductName>{product.name}</ProductName>
      <Grid container spacing={2}>
        <Grid item xs={6}>
          <ProductImage src={product.pictureUri} alt={product.name}/>
        </Grid>
        <Grid item xs={4}>
          <DescriptionHeader>Description:</DescriptionHeader>
          <ProductDescription>{product.description}</ProductDescription>
        </Grid>
        <Grid item xs={2}>
          <ProductPrice>$ {product.price > 0 ? product.price.toFixed(2) : product.price}</ProductPrice>
        </Grid>
      </Grid>
    </StyledDiv>
  );
}

export default ProductDetails;

const StyledDiv = styled.div`
  margin-bottom: 16px;
`

const ProductImage = styled.img`
  max-width: 60%;
  margin-left: auto;
  float: right;
`

const ProductName = styled.h1`
  font-size: 28px;
  margin-bottom: 8px;
`
const DescriptionHeader = styled.h1`
  font-size: 18px;
  margin-bottom: 8px;
`

const ProductDescription = styled.p`
  font-size: 18px;
  text-align: left;
  margin-bottom: 8px;
`

const ProductPrice = styled.p`
  font-size: 18px;
  font-weight: bold;
`
