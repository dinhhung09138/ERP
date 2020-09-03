import { FunctionCommandInterface } from './function-command.interface';

export interface FunctionInterface {
  code: string;
  name: string;
  url: string;
  icon: string;
  parentCode: string;
  precedence: number;
  moduleCode: string;
  commands: FunctionCommandInterface[];
}
