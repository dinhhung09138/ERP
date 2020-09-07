import { FunctionCommandInterface } from './../../../core/interfaces/function-command.interface';
import { BaseViewModel } from '../../../core/models/base.model';

export interface RoleViewModel extends BaseViewModel{
    name: string;
    description: string;
    commands: FunctionCommandInterface[];
}
