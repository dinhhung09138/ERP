import { BaseViewModel } from "src/app/core/models/base.mode";

export interface EContactViewModel extends BaseViewModel {
    phone: string;
    mobile: string;
    email: string;
    skyper: string;
    temporaryAddress: string;
    permanentAddress: string;
}