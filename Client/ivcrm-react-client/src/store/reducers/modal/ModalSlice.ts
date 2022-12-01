import { createSlice, PayloadAction } from "@reduxjs/toolkit"

interface IModalState {
    data: any;
    isOpen: boolean;
}

const initialState: IModalState = {
    data: {},
    isOpen: false,
}

export const modalSlice = createSlice({
    name: 'modal',
    initialState,
    reducers: {
        openModal(state, action: PayloadAction<any>) {
            state.isOpen = true;
            state.data = action.payload;
        },
        closeModal(state) {
            state.isOpen = false;
            state.data = {};
        }
    },
})

export const ModalActions = modalSlice.actions;
export default modalSlice.reducer;
