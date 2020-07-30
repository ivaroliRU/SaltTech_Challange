import React from 'react';
import { connect } from 'react-redux';
import PagiNationWrapper from './PaginationWrapper';
import PaginationItem from './PaginationItem';

const DOMAIN_SIZE = 5;

class Pagination extends React.Component {
    constructor(props) {
        super(props);

        this.calculateDomain = this.calculateDomain.bind(this);
    }

    //calculate the range/domain of where the pagination buttons should start and end
    calculateDomain() {
        let domain_range = [this.props.page, this.props.page];
        var domain = [];

        for (let i = 0; i < DOMAIN_SIZE / 2; i++) {
            domain_range[1]++;

            if (domain_range[0] > 0) {
                domain_range[0]--;
            }
            else {
                domain_range[1]++;
            }
        }

        for (var i = domain_range[0]; i < domain_range[1]; i++) {
            domain.push(i);
        }
        return domain;
    }

    render() {
        let domain = this.calculateDomain();

        return (
            <PagiNationWrapper>
                    <PaginationItem disabled={this.props.page === 0} onClick={() => (this.props.page > 0) ? this.props.changePage(this.props.page - 1) : null}>
                        Previous
                    </PaginationItem>
                    {domain.map(i => (
                        <PaginationItem active={this.props.page === i} key={"pagination-" + i} onClick={() =>this.props.page !== i && this.props.changePage(i)}>
                            {i}
                        </PaginationItem>))}
                    <PaginationItem onClick={() => this.props.changePage(this.props.page + 1)}>
                        Next
                    </PaginationItem>
                </PagiNationWrapper>
        );
    }
}

function mapStateToProps(state) {
    return {
        page: state.page,
    };
}

const mapDispatchToProps = dispatch => {
    return {
        changePage: (page) => dispatch({ type: 'CHANGE_PAGE', payload: page })
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(Pagination);