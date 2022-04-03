import { student } from "./student.model";

export interface address
{
  id: string,
  postalAddress: string,
  physicalAddress: string,
  studendId : student;
}
