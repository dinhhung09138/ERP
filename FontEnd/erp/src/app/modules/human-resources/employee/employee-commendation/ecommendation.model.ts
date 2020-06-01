import {BaseViewModel} from 'src/app/core/models/base.mode'

export interface ECommendationViewModel extends BaseViewModel{
    title:string;
    money: number;
    comment: string;
    approvedStatus: boolean;
}