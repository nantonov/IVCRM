import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { useParams } from 'react-router-dom';
import { useEffect } from 'react';
import ProductDetails from '../products/ProductDetails';
import { getProductById, uploadPicture } from '../../store/reducers/products/ActionCreators';
import { IPictureModel } from '../../models/IPictureModel';

function ProductDetailsPage() {
  const {product} = useAppSelector(state => state.productReducer)
  const params = useParams();
  const dispatch = useAppDispatch()

  var productId = 0;
if (typeof(params.productId) !== 'undefined' && params.productId != null) {
  productId = parseInt(params.productId, 10);
}

const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
  var file = e.target.files?.[0];
  if (file == null) {
    return;
  }

  var pictureModel: IPictureModel = {
    id: product.id,
    picture: file,
  }

  dispatch(uploadPicture(pictureModel));
};

useEffect(() => {
  dispatch(getProductById(productId))
}, [])

  return (
    <div>
    <ProductDetails product={product}/>
    <input type="file" accept="image/jpeg, image/jpg, image/png" onChange={handleChange} />
    </div>
  );
}

export default ProductDetailsPage;