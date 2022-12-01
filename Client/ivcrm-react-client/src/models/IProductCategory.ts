export interface IProductCategory {
    id: number;
    name: string;
    parentCategoryId: number;
    childCategories: Array<IProductCategory>;
}