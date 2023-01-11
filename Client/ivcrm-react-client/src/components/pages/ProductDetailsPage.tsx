import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { useParams } from 'react-router-dom';
import { useEffect } from 'react';
import ProductDetails from '../products/ProductDetails';
import { getProductById, uploadPicture } from '../../store/reducers/products/ActionCreators';
import { IPictureModel } from '../../models/IPictureModel';
import Dropzone from '../buildingBlocks/DropZone';

function ProductDetailsPage() {
  const {product} = useAppSelector(state => state.productReducer)
  const params = useParams();
  const dispatch = useAppDispatch()

  var productId = 0;
  if (typeof(params.productId) !== 'undefined' && params.productId != null) {
    productId = parseInt(params.productId, 10);
  }

  const handleFile = (file: File) => {
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
      <hr/>
      <h2>Change picture for product</h2>
      <Dropzone onFileUpload={handleFile} inputProps={{ accept: ".jpg, .jpeg, .png"}}/>
    </div>
  );
}

export default ProductDetailsPage;