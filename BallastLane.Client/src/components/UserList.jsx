import { useEffect, useState } from 'react';
import { getAllUsers } from "../services/userService";
import DataTable, {createTheme} from 'react-data-table-component';

const UserTable = () => {

    const columns = [
        {
            name: 'Id',
            selector: row => row.id,
        },
        {
            name: 'Name',
            selector: row => row.name,
        },
        {
            name: 'Last Name',
            selector: row => row.lastName,
        },
        {
            name: 'Phone Number',
            selector: row => row.phoneNumber,
        },
        {
            name: 'Date of Birth',
            selector: row => row.dateOfBirth,
        },
        {
            name: 'Address',
            selector: row => row.address,
        },
    ];
    const [data, setData] = useState();

    createTheme('solarized', {
        text: {
          primary: '#268bd2',
          secondary: '#2aa198',
        },
        background: {
          default: '#002b36',
        },
        context: {
          background: '#cb4b16',
          text: '#FFFFFF',
        },
        divider: {
          default: '#073642',
        },
        action: {
          button: 'rgba(0,0,0,.54)',
          hover: 'rgba(0,0,0,.08)',
          disabled: 'rgba(0,0,0,.12)',
        },
      }, 'dark');
    useEffect(() => {
        const fetchData = async () => {
            try {
                const users = await getAllUsers();
                console.log(users)
                setData(users);
            } catch (error) {
                
            }
        };

        fetchData();
    }, []);

    return (
        <DataTable
            columns={columns}
            data={data}
            pagination
            fixedHeader
            striped
            highlightOnHover
        />
    );
};

export default UserTable;
