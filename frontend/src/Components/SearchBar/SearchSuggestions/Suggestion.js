import styled from 'styled-components';

export default styled.li`
    padding: 5px 10px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;

    &:hover {
        cursor: pointer;
        background-color: #DDD;
    }
`;