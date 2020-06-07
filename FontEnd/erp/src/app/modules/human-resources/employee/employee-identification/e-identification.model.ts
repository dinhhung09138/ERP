import {BaseViewModel} from "src/app/core/models/base.mode"

export interface IdentificationViewModel extends BaseViewModel{
    code:string
    name:string;
    notes:string;
}