import { BaseViewModel } from 'src/app/core/models/base.mode';

export interface InfoViewModel extends BaseViewModel {
    firstName: string;
    lastName: string;
    gender: boolean;
    dateOfBirth: Date;
}