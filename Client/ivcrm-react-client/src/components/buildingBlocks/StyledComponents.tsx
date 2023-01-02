import { Card } from '@mui/material';
import styled from 'styled-components';

export const StyledModalBox = styled.div`
   position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 400;
    background-color: white;
    border: 2px solid #000;
    box-shadow: 24;
    padding: 40px;
    `
export const StyledCard = styled(Card)`
  width: 100%; 
  display: flex;
  justify-content: space-between;
  flex-direction: column;
`;