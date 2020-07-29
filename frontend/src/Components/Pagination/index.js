import React from 'react';
import { connect } from 'react-redux';
import './style.css';

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
            <nav aria-label="..." className="product-page-controller">
                <ul className="pagination">
                    <li className={(this.props.page === 0) ? "page-item disabled" : "page-item"}>
                        <a className="page-link" onClick={() => (this.props.page > 0) ? this.props.changePage(this.props.page - 1) : null}>Previous</a>
                    </li>
                    {domain.map(i => {
                        if (this.props.page === i) {
                            return (
                                <li className="page-item active" key={"pagination-" + i}>
                                    <a className="page-link">{i} <span className="sr-only">(current)</span></a>
                                </li>
                            );
                        }
                        else {
                            return (
                                <li className="page-item" key={"pagination-" + i}><a className="page-link" onClick={() => this.props.changePage(i)}>{i}</a></li>
                            );
                        }
                    })}
                    <li className="page-item">
                        <a className="page-link" onClick={() => this.props.changePage(this.props.page + 1)}>Next</a>
                    </li>
                </ul>
            </nav>
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