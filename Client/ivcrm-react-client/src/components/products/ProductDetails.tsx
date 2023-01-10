import { Box } from '@mui/material';
import { IProduct } from '../../models/IProduct';

interface Props {
  product: IProduct
}

const ProductDetails: React.FC<Props> = ({ product }) => {
  return (
    <div>
      <p>{product.name}</p>
    <Box
    component="img"
    sx={{
      height: 233,
      width: 350,
      maxHeight: { xs: 233, md: 167 },
      maxWidth: { xs: 350, md: 250 },
    }}
    alt="The house from the offer."
    src={product.pictureUri}
  />
  </div>
  );
}

export default ProductDetails;