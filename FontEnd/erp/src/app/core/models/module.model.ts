import { FunctionViewModel } from './function.model';

export interface ModuleViewModel {
  code: string;
  name: string;
  url: string;
  icon: string;
  parentCode: string;
  precedence: number;
  functions: FunctionViewModel[];
}
