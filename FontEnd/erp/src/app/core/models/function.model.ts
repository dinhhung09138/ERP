import { FunctionCommandViewModel } from '../models/function-command.model';

export interface FunctionViewModel {
  code: string;
  name: string;
  url: string;
  icon: string;
  parentCode: string;
  precedence: number;
  moduleCode: string;
  commands: FunctionCommandViewModel[];
}
